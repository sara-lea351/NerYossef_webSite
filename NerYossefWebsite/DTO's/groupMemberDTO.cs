﻿namespace NerYossefWebsite.DTO_s
{
    public class groupMemberDTO
    {
        public int GroupMemberId { get; set; }

        public int GroupId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
