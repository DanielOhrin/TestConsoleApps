namespace TestConsoleApps.Winnables.Hierarchy
{
    public abstract class Winnable
    {
        #region Abstract Methods

        #region Public Methods

        /// <summary>
        /// Executes the Winnable
        /// </summary>
        public abstract void Run();

        #endregion


        #region Protected Methods

        /// <summary>
        /// Executes a single play-through of the winnable
        /// </summary>
        /// <returns>Whether the player won</returns>
        protected abstract bool Play();

        /// <summary>
        /// Executes the settings menu 
        /// </summary>
        protected abstract void Settings();

        #endregion

        #endregion

        #region Defined Methods

        public override string ToString()
        {
            return GetType().Name;
        }

        #endregion
    }
}
