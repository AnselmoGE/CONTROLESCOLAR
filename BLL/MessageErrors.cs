using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public static class MessageErrors
    {
        static readonly Dictionary<int, string> errorDictionary = new Dictionary<int, string>
        {
            
            {1, "Bad DB connection credentials." },
            {2, "Connection Closed." },
            {3, "Session expired." },
            {4, "Could not connect to the DB." },
            {5, "Unsuccessful method." },
            {6, "Incorrect username and / or password." },
            {7, "No information." },
            {8, "Could not register in the DB." },
            {9, "Incorrect configuration of the URL to the web service." },
            {10, "Repeated information." },
            {11, "Is not available." },
            {12, "Invalid credentials." },
            {13, "Inactive User." },
            {14, "Username does not exist." },       
            {15, "Could not be deleted in the DB." },
            {16, "La hora seleccionada ya se encuentra ocupada" },
            {17, "La Materia Seleccionada ya se encuentra asignada al grupo" }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseResponse"></param>
        /// <param name="errorCode"></param>
        public static void SetErrorCode(this BaseResponse baseResponse, int errorCode)
        {
            baseResponse.CodeError = errorCode;
            if (errorDictionary.ContainsKey(errorCode))
                baseResponse.MessageError = errorDictionary[errorCode];

        }
    }
}
