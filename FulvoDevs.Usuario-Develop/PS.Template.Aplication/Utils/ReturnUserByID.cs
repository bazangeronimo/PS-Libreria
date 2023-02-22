namespace PS.Template.Aplication.Utils
{
    public class ReturnUserByID
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public int? followers { get; set; }
        public int? following { get; set; }
        public string? profilePicture { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public int? Edad { get; set; }
        public string? SockerTeam { get; set; }
        public string? Ubication { get; set; }
        public string? description { get; set; }
        public List<string>? features { get; set; }
        public bool softDelete { get; set; }
        public bool? followedOrNot { get; set; } = null;
    }
}