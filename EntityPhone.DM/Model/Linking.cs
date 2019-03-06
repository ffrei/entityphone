using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPhone.DM.Model
{
    public partial class client : IClient
    {
        public int GetClientId() { return this.client_id; }
        public void SetClientId(int val) { this.client_id = val; }
        public int GetSellerId() { return this.seller_id; }
        public void SetSellerId(int val) { this.seller_id = val; }
        public string GetName() { return this.name; }
        public void SetName(string val) { this.name = val; }
        public DateTime GetBirthday() { return this.birthday; }
        public void SetBirthDay(DateTime val) { this.birthday = val; }
    }
    public partial class history : IHistory
    {
        public int GetHistoryId() { return this.history_id; }
        public void SetHistoryId(int val) { this.history_id = val; }
        public int GetSubscriptionId() { return this.subscription_id; }
        public void SetSubscriptionId(int val) { this.subscription_id = val; }
        public DateTime GetTimestamp() { return this.timestamp; }
        public void SetTimestamp(DateTime val) { this.timestamp = val; }
        public string GetDestinationNumber() { return this.destination_number; }
        public void SetDestinationNumber(string val) { this.destination_number = val; }
        public string GetPhoneCode() { return this.phone_code; }
        public void SetPhoneCode(string val) { this.phone_code = val; }
    }
    public partial class call_history : ICallHistory
    {
        public int GetDuration() { return this.duration; }
        public void SetDuration(int val) { this.duration = val; }
    }
    public partial class option : IOption
    {
        public int GetOptionId(){ return this.option_id; }
        public void SetOptionId(int val){ this.option_id = val; }
        public int GetMinuteLimit(){ return this.minute_limit; }
        public void SetMinuteLimit(int val){ this.minute_limit = val; }
        public int GetSMSLimit(){ return this.sms_limit; }
        public void SetSMSLimit(int val){ this.sms_limit = val; }
        public decimal GetPrice(){ return this.price; }
        public void SetPrice(decimal val){ this.price = val; }
        public decimal GetOverageMinutePrice(){ return this.overage_minute_price; }
        public void SetOverageMinutePrice(decimal val){ this.overage_minute_price = val; }
        public decimal GetOverageSMSPrice(){ return this.overage_sms_price; }
        public void SetOverageSMSPrice(decimal val){ this.overage_sms_price = val; }
        public bool GetIsAvailable(){ return this.is_available; }
        public void SetIsAvailable(bool val){ this.is_available = val; }
    }
    public partial class plan : IPlan
    {
        public int GetPlanId(){ return this.plan_id; }
        public void SetPlanId(int val){ this.plan_id = val; }
        public string GetName(){ return this.name; }
        public void SetName(string val){ this.name = val; }
        public int GetMinuteLimit(){ return this.minute_limit; }
        public void SetMinuteLimit(int val){ this.minute_limit = val; }
        public int GetSMSLimit(){ return this.sms_limit; }
        public void SetSMSLimit(int val){ this.sms_limit = val; }
        public decimal GetPrice(){ return this.price; }
        public void SetPrice(decimal val){ this.price = val; }
        public decimal GetOverageMinutePrice(){ return this.overage_minute_price; }
        public void SetOverageMinutePrice(decimal val){ this.overage_minute_price = val; }
        public decimal GetOverageSMSPrice(){ return this.overage_sms_price; }
        public void SetOverageSMSPrice(decimal val){ this.overage_sms_price = val; }
        public bool GetIsAvailable(){ return this.is_available; }
        public void SetIsAvailable(bool val){ this.is_available = val; }
    }
    public partial class sms_history : ISMSHistory
    {

    }

    public partial class sub_option : ISubOption
    {
        public int GetSubOptionId() { return this.sub_option_id; }
        public void SetSubOptionId(int val) { this.sub_option_id = val; }
        public int GetSubscriptionId() { return this.subscription_id; }
        public void SetSubscriptionId(int val) { this.sub_option_id = val; }
        public int GetOptionId() { return this.option_id; }
        public void SetOptionId(int val) { this.option_id = val; }
        public DateTime GetStartDate() { return this.start_date; }
        public void SetStartDate(DateTime val) { this.start_date = val; }
        public DateTime GetEndDate() { return this.end_date; }
        public void SetEndDate(DateTime val) { this.end_date = val; }
    }
    public partial class subscription : ISubscription
    {
        public int GetSubscriptionId() { return this.subscription_id; }
        public void SetSubscriptionId(int val) { this.subscription_id = val; }
        public int GetPlanId() { return this.plan_id; }
        public void SetPlanId(int val) { this.plan_id = val; }
        public int GetClientId() { return this.client_id; }
        public void SetClientId(int val) { this.client_id = val; }
        public string GetPhoneNumber() { return this.phone_number; }
        public void SetPhoneNumber(string val) { this.phone_number = val; }
        public DateTime GetStartDate() { return this.start_date; }
        public void SetStartDate(DateTime val) { this.start_date = val; }
        public DateTime? GetEndDate() { return this.end_date; }
        public void SetEndDate(DateTime val) { this.end_date = val; }
    }



}
