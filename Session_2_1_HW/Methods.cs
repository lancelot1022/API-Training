using System;
using System.Collections.Generic;
using RestSharp;
using System.Text.RegularExpressions;

namespace Session_2_1_HW
{
    class Methods
    {
        const string baseURL = "https://magenicmovies-api.azurewebsites.net/";
        const string branchEndPoint = "branches";

        public string BranchRecordCount()
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest($"{baseURL}{branchEndPoint}");
            var branchID = "0";

            var response = restClient.Get<List<BranchJSONModel>>(restRequest);
            if(response.Data != null)
            {
                BranchJSONModel[] arrBranch = response.Data.ToArray();
                branchID = arrBranch.Length.ToString();
            }
            else
            {
                var indexID = response.Content.ToLower().LastIndexOf("\"id\":");
                var idString = response.Content.Substring(indexID);
                Regex reg = new Regex(@"\d+");
                branchID = reg.Match(idString).ToString();
            }

            return branchID;
        }

    }
}
