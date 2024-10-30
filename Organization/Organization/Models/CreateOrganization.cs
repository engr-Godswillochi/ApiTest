using System.ComponentModel.DataAnnotations;

namespace Organization.Models
{
    public class CreateOrganization
    {
        public int ID { get; set; }
        public string? OrganizationName { get; set; }
       
        public string? OrganizationDescription { get; set; }
        
        //This will the special tag of the organizaton
        public string? OrganizationHandle { get; set; }

        //Will it be private or public
        public bool OrganizationPrivateStatus { get; set; }
    }
}
