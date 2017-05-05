using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models.CrmManager
{
    public class CloseDiscussionListRequest:Request
    {
            public CloseDiscussionRequest _CloseDiscussionRequest { get; set; }


            public CloseDiscussionListRequest()
            {
                _CloseDiscussionRequest = new CloseDiscussionRequest();
            }

        
    }
}
