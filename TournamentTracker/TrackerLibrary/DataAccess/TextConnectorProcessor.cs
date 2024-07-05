using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {

        /** Note: Extension Methods allow users to add new methods to existing types without 
         * creating a new derived type, recompiling, or otherwise modifying the original type. 
         * Extension methods are a special kind of static method, but they are called as if 
         * they were instance methods on the extended type. For client code written in C#, 
         * there is no apparent difference between calling an extension method and the methods 
         * that are actually defined in a type.
         */

        /// <summary>
        /// Takes the filename and returns the full file path.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>
        /// The full file path.
        /// </returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        /// <summary>
        /// Reads the text file and returns the list of strings.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>
        /// The list of strings from the text file.
        /// </returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Takes the list of lines of a text file and returns the list of PrizeModel objects.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>
        /// List of PrizeModel objects.
        /// </returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<String> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Takes the list of PrizeModel objects and saves them to the text file.
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
