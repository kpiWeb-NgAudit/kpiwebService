using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class OlapQueryLog
{
    public string? MSOLAP_Database { get; set; }

    public string? MSOLAP_ObjectPath { get; set; }

    public string? MSOLAP_User { get; set; }

    public string? Dataset { get; set; }

    public DateTime? StartTime { get; set; }

    public long? Duration { get; set; }
}
