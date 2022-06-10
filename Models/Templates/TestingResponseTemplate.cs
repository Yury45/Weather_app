namespace WPF_MVVM_Template.Models.Templates
{
    internal class TestingResponseTemplate
    {
        public bool ok { get; set; }
        public Result result { get; set; }
    }

    internal class Result
    {
        public long id { get; set; }
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
        public bool can_join_groups { get; set; }
        public bool can_read_all_group_messages { get; set; }
        public bool supports_inline_queries { get; set; }
    }
}


