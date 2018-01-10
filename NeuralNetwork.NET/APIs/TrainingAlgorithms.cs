﻿using JetBrains.Annotations;
using NeuralNetworkNET.SupervisedLearning.Algorithms.Info;

namespace NeuralNetworkNET.APIs
{
    /// <summary>
    /// A static class that produces info for different available training algorithms
    /// </summary>
    public static class TrainingAlgorithms
    {
        /// <summary>
        /// Gets an instance implementing <see cref="Interfaces.ITrainingAlgorithmInfo"/> for the <see cref="SupervisedLearning.Algorithms.TrainingAlgorithmType.StochasticGradientDescent"/> algorithm
        /// </summary>
        /// <param name="eta">The learning rate</param>
        /// <param name="lambda">The lambda regularization parameter</param>
        [PublicAPI]
        [Pure, NotNull]
        public static StochasticGradientDescentInfo StochasticGradientDescent(float eta = 0.1f, float lambda = 0f) => new StochasticGradientDescentInfo(eta, lambda);

        /// <summary>
        /// Gets an instance implementing <see cref="Interfaces.ITrainingAlgorithmInfo"/> for the <see cref="SupervisedLearning.Algorithms.TrainingAlgorithmType.Momentum"/> algorithm
        /// </summary>
        /// <param name="eta">The learning rate</param>
        /// <param name="lambda">The lambda regularization parameter</param>
        /// <param name="momentum">The momentum value</param>
        [PublicAPI]
        [Pure, NotNull]
        public static StochasticGradientDescentInfo Momentum(float eta = 0.1f, float lambda = 0f, float momentum = 0.1f) => momentum > 0
            ? new MomentumInfo(eta, lambda, momentum)
            : new StochasticGradientDescentInfo(eta, lambda); // Momentum to 0 reduces the algorithm to plain SGD

        /// <summary>
        /// Gets an instance implementing <see cref="Interfaces.ITrainingAlgorithmInfo"/> for the <see cref="SupervisedLearning.Algorithms.TrainingAlgorithmType.Adadelta"/> algorithm
        /// </summary>
        /// <param name="rho">The Adadelta rho parameter</param>
        /// <param name="epsilon">The Adadelta epsilon parameter</param>
        /// <param name="l2">An optional L2 regularization parameter</param>
        [PublicAPI]
        [Pure, NotNull]
        public static AdadeltaInfo Adadelta(float rho = 0.95f, float epsilon = 1e-8f, float l2 = 0f) => new AdadeltaInfo(rho, epsilon, l2);

        /// <summary>
        /// Gets an instance implementing <see cref="Interfaces.ITrainingAlgorithmInfo"/> for the <see cref="SupervisedLearning.Algorithms.TrainingAlgorithmType.Adam"/> algorithm
        /// </summary>
        /// <param name="eta">The learning rate factor</param>
        /// <param name="beta1">The beta1 factor for the first moment vector</param>
        /// <param name="beta2">The beta2 factor for the second moment vector</param>
        /// <param name="epsilon">The Adadelta epsilon parameter</param>
        [PublicAPI]
        [Pure, NotNull]
        public static AdamInfo Adam(float eta = 0.001f, float beta1 = 0.9f, float beta2 = 0.999f, float epsilon = 1e-8f) => new AdamInfo(eta, beta1, beta2, epsilon);

        /// <summary>
        /// Gets an instance implementing <see cref="Interfaces.ITrainingAlgorithmInfo"/> for the <see cref="SupervisedLearning.Algorithms.TrainingAlgorithmType.AdaMax"/> algorithm
        /// </summary>
        /// <param name="eta">The learning rate factor</param>
        /// <param name="beta1">The beta1 factor for the first moment vector</param>
        /// <param name="beta2">The beta2 factor for the second moment vector</param>
        [PublicAPI]
        [Pure, NotNull]
        public static AdaMaxInfo AdaMax(float eta = 0.002f, float beta1 = 0.9f, float beta2 = 0.999f) => new AdaMaxInfo(eta, beta1, beta2);
    }
}
