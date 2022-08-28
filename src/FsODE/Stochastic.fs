namespace FsODE

module Stochastic =

    /// Simulate size sets of n coin flips with prob. p of heads
    let simulateCoinflips n p size =
        let rnd = new System.Random()
        [|0 .. size - 1|]
        |> Array.map (fun _ ->
            Array.init n (fun x -> rnd.NextDouble())
            |> Array.countBy (fun x -> x < p)
            |> Array.tryFind (fun (isHead,count) -> isHead)
            |> fun res ->
                match res with
                | Some (isHead,count) -> count
                | None -> 0
        )

    /// Randomly sample an index with probability given by probs.
    let sampleDiscrete (probs: float []) =
        let q =  (new System.Random()).NextDouble()
        let mutable i = 0
        let mutable pSum = 0.
        while pSum < q do
            pSum <- pSum + probs.[i]
            i <- i + 1
        i - 1

    /// Draws a reaction and the time it took to do that reaction.
    /// 
    /// Parameters
    ///
    /// ----------
    ///
    /// propensity_func : function
    ///     Function with call signature propensityFunc(population, t, *args)
    ///     used for computing propensities. This function must return
    ///     an array of propensities.
    /// propensities : float array
    ///     Propensities for each reaction as an array.
    /// population : ndarray
    ///     Current population of particles
    /// t : float
    ///     Value of the current time.
    /// beta_m beta_p gamma : float float float
    ///     Arguments to be passed to `propensityFunc`.
    /// 
    /// Returns
    ///
    /// -------
    ///
    /// rxn : int
    ///     Index of reaction that occured.
    /// time : float
    ///     Time it took for the reaction to occur.
    let gillespieDraw propensityFunc propensities population t beta_m beta_p gamma =
        // compute propensities
        propensityFunc propensities population t beta_m beta_p gamma
        // sum of propensities
        let  propsSum = propensities |> Array.sum
        let time = (FSharp.Stats.Distributions.Continuous.exponential propsSum).Sample()
        // compute discrete probabilities of each reaction
        let rxnProbs = propensities |> Array.map (fun p -> p / propsSum)
        // draw reaction from this distribution
        let rxn = sampleDiscrete rxnProbs
        rxn, time

    /// Uses the Gillespie stochastic simulation algorithm to sample
    /// from probability distribution of particle counts over time.
    /// 
    /// Parameters
    ///
    /// ----------
    ///
    /// propensityFunc : function
    ///     Function of the form f(params, t, population) that takes the current
    ///     population of particle counts and return an array of propensities
    ///     for each reaction.
    /// update : (float*float)[]
    ///     Entry i, j gives the change in particle counts of species j
    ///     for chemical reaction i.
    /// population0 : float*float
    ///     Array of initial populations of all chemical species.
    /// time_points : float[]
    ///     Array of points in time for which to sample the probability
    ///     distribution.
    /// beta_m beta_p gamma : float float float
    ///     Arguments to be passed to `propensityFunc`.
    /// 
    /// Returns
    ///
    /// -------
    ///
    /// sample : ndarray, shape (num_time_points, num_chemical_species)
    ///     Entry i, j is the count of chemical species j at time
    ///     time_points[i].
    let gillespieSSA propensityFunc (update: (float*float)[]) (population0:float*float) (timePoints: float[]) beta_m beta_p gamma =
        // initialize output
        let mutable popOut: (float*float)[] = Array.init timePoints.Length (fun x -> 0.,0.)

        // initialize and perform simulation
        let mutable iTime = 1
        let mutable i = 0
        let mutable t = timePoints.[0]
        let mutable population = population0
        let mutable propensities = Array.zeroCreate update.Length
        let mutable populationPrevious = 0.,0.
        popOut.[0] <- population
        while i < timePoints.Length do
            while t < timePoints.[iTime] do
                // draw the event and time step
                let event, dt = gillespieDraw propensityFunc propensities population t beta_m beta_p gamma
                // update the population
                populationPrevious <- population
                population <- fst populationPrevious + fst update.[event], snd populationPrevious + snd update.[event]
                // increment time
                t <- t + dt
            // update the index
            i <- 
                match (timePoints |> Array.tryFindIndex (fun x -> x > t)) with
                | Some x -> x
                | None -> i + 1
            // update the population
            popOut.[iTime] <- populationPrevious
            // increment index
            iTime <- i
        Array.unzip popOut


    