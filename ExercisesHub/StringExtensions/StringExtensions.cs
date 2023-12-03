using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace LeetCodeRunner.ExercisesHub.StringExtensions
{
    public static class StringExtensions
    {
        public static Dictionary<int,string> GetHashedExercisesList(this string rootFolder)
        {   
            /* Dictionary used to relate exercises numbers to the corresponding files
            Example: For the file P_1_TwoSum, the tuple will be >> 1 - P_1_TwoSum */
            Dictionary<int, string> exercisesNumAndFile = new Dictionary<int, string>();
            
            string[] fileNames = Directory.GetFiles(rootFolder);
            
            foreach (string fileName in fileNames)
            {
                // Split the name in 3 parts by '_': [P, exerciseNumber, exerciseName]
                string[] fileNameComponents = fileName.Split('_');
                // Add tuple to the hashTable
                exercisesNumAndFile.Add(int.Parse(fileNameComponents[1]), Path.GetFileNameWithoutExtension(fileName));
            }

            return exercisesNumAndFile;
        }
        
    }
}