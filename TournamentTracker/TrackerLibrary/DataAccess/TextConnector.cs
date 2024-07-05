using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModel.csv";

        /// <summary>
        /// Saves a new prize to the text file.
        /// </summary>
        /// <param name="model">
        /// The prize information.
        /// </param>
        /// <returns>
        /// The prize information, including the unique identifier.
        /// </returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            /** Note: We are using Extension methods defined in TextConnectorProcessor
             */
            // Load the text file
            List<string> fileLines = PrizesFile.FullFilePath().LoadFile();

            // Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = fileLines.ConvertToPrizeModels();

            // Find the max ID
            int currentId = 0;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id;
            }

            // Add the new record with the new ID  (max + 1)
            model.Id = currentId + 1;
            prizes.Add(model);

            // Converge the prizes to List<string> and Save the List<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
