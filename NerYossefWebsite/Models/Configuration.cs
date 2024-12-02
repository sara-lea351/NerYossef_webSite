using System;
using System.Collections.Generic;

namespace NerYossefWebsite.Models;

public partial class Configuration
{
    public int ConfigurationId { get; set; }

    public string KeyName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Description { get; set; } = null!;
}
