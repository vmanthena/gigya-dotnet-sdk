// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Collections.Generic;
using System;

public class POSreceipt
{
    public string flag { get; set; }
    public string optIn { get; set; }
    public string SMS { get; set; }
    public string email { get; set; }
}

public class AboutMe
{
    public bool showIndicator { get; set; }
    public bool showPopup { get; set; }
}

public class Preferences
{
    public POSreceipt POSreceipt { get; set; }
    public string preferredStore { get; set; }
    public string emailMarketing { get; set; }
    public AboutMe aboutMe { get; set; }
}

public class TandC
{
    public string acceptanceDate { get; set; }
    public string acceptedVersion { get; set; }
    public string accepted { get; set; }
}

public class Data
{
    public Preferences preferences { get; set; }
    public string couponToken { get; set; }
    public string flags { get; set; }
    public string accountSource { get; set; }
    public TandC TandC { get; set; }
}

public class Emails
{
    public List<string> verified { get; set; }
    public List<object> unverified { get; set; }
}

public class Profile
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
}

public class UserInfoResponse
{
    public string callId { get; set; }
    public int errorCode { get; set; }
    public int apiVersion { get; set; }
    public int statusCode { get; set; }
    public string statusReason { get; set; }
    public DateTime time { get; set; }
    public long registeredTimestamp { get; set; }
    public string UID { get; set; }
    public DateTime created { get; set; }
    public long createdTimestamp { get; set; }
    public Data data { get; set; }
    public Preferences preferences { get; set; }
    public Emails emails { get; set; }
    public bool isActive { get; set; }
    public bool isRegistered { get; set; }
    public bool isVerified { get; set; }
    public DateTime lastLogin { get; set; }
    public long lastLoginTimestamp { get; set; }
    public DateTime lastUpdated { get; set; }
    public long lastUpdatedTimestamp { get; set; }
    public string loginProvider { get; set; }
    public DateTime oldestDataUpdated { get; set; }
    public long oldestDataUpdatedTimestamp { get; set; }
    public Profile profile { get; set; }
    public DateTime registered { get; set; }
    public string socialProviders { get; set; }
    public DateTime verified { get; set; }
    public long verifiedTimestamp { get; set; }
}

