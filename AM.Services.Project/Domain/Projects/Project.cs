using AM.Common.Types;
using System;
using System.Xml.Linq;

namespace AM.Services.Projects.Domain.Projects
{
    public class Project : BaseEntity
    {
        public Project(Guid id,string name ,string description,string tempalte,string client ,DateTime startdate,DateTime enddate, bool Invitationsend) : base(id)
        {

            SetName(name); 
            SetDescription(description);
            SetTemplate (tempalte);
            SetClient (client);
            SetStartDate (startdate);
            SetEndDate (enddate);
            SetInvitationSend (Invitationsend);
        }
      
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean InvitationSend { get; set; }


        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new AMException("empty_product_name",
                    "Product name cannot be empty.");
            }

            Name = name.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }

        public void SetDescription(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new AMException("empty_product_name",
                    "Product name cannot be empty.");
            }

            Description = name.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }

        public void SetTemplate(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new AMException("empty_product_name",
                    "Product name cannot be empty.");
            }

            Template  = name.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }

        public void SetClient(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new AMException("empty_product_name",
                    "Product name cannot be empty.");
            }

            Client = name.Trim().ToLowerInvariant();
            SetUpdatedDate();
        }
        public void SetStartDate(DateTime startdate)
        {
            //if (DateTime.)
            //{
            //    throw new DShopException("empty_product_name",
            //        "Product name cannot be empty.");
            //}

            StartDate = startdate ;
            ;
            SetUpdatedDate();
        }
        public void SetEndDate(DateTime enddate)
        {
            //if (DateTime.)
            //{
            //    throw new DShopException("empty_product_name",
            //        "Product name cannot be empty.");
            //}

            EndDate  = enddate;
            ;
            SetUpdatedDate();
        }

        public void SetInvitationSend(Boolean invitesend)
        {
            //if (DateTime.)
            //{
            //    throw new DShopException("empty_product_name",
            //        "Product name cannot be empty.");
            //}

            InvitationSend = invitesend;
            
            SetUpdatedDate();
        }
    }
}