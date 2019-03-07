using EntityPhone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(this.name, "^[a-zA-Z ]*$"))
                yield return new ValidationResult("Name can't be numbers or special characters");
            if (this.birthday > DateTime.Today)
                yield return new ValidationResult("Are you a time traveler ? Birthday cannot be in the future !");
            if ((this.birthday - DateTime.Today).TotalDays< 6570 || (this.birthday - DateTime.Today).TotalDays > 40150)
                yield return new ValidationResult("You need to be at least 18 years old and less that 110 years old !");
        }
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(this.destination_number, "^\\d{9-12}$"))
                yield return new ValidationResult("Destination number can only be numerics");
            if (!Regex.IsMatch(this.destination_number, "^\\+\\d{1-3}$"))
                yield return new ValidationResult("Phone code must be + and digits 1-3");
            if (this.timestamp > DateTime.Now)
                yield return new ValidationResult("Are you a time traveler ? Historic Timestamp cannot be in the future !");
        }

    }
    public partial class call_history : ICallHistory
    {
        public int GetDuration() { return this.duration; }
        public void SetDuration(int val) { this.duration = val; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.duration < 1)
                yield return new ValidationResult("Duration must be positive");
            base.Validate(validationContext);
        }

    }
    public partial class option : IOption
    {
        public int GetOptionId() { return this.option_id; }
        public void SetOptionId(int val) { this.option_id = val; }
        public int GetMinuteLimit() { return this.minute_limit; }
        public void SetMinuteLimit(int val) { this.minute_limit = val; }
        public int GetSMSLimit() { return this.sms_limit; }
        public void SetSMSLimit(int val) { this.sms_limit = val; }
        public decimal GetPrice() { return this.price; }
        public void SetPrice(decimal val) { this.price = val; }
        public bool GetIsAvailable() { return this.is_available; }
        public void SetIsAvailable(bool val) { this.is_available = val; }
        public string GetName() { return this.name; }
        public void SetName(string val) { this.name = val; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(this.name, "^[a-zA-Z ]*$"))
                yield return new ValidationResult("Name can't be numbers or special characters");
            if (this.minute_limit < 0 || this.sms_limit < 0)
                yield return new ValidationResult("Limits must be positives");
            if (this.price < 0)
                yield return new ValidationResult("Price must be positive");
        }
    }
    public partial class plan : IPlan
    {
        public int GetPlanId() { return this.plan_id; }
        public void SetPlanId(int val) { this.plan_id = val; }
        public string GetName() { return this.name; }
        public void SetName(string val) { this.name = val; }
        public int GetMinuteLimit() { return this.minute_limit; }
        public void SetMinuteLimit(int val) { this.minute_limit = val; }
        public int GetSMSLimit() { return this.sms_limit; }
        public void SetSMSLimit(int val) { this.sms_limit = val; }
        public decimal GetPrice() { return this.price; }
        public void SetPrice(decimal val) { this.price = val; }
        public decimal GetOverageMinutePrice() { return this.overage_minute_price; }
        public void SetOverageMinutePrice(decimal val) { this.overage_minute_price = val; }
        public decimal GetOverageSMSPrice() { return this.overage_sms_price; }
        public void SetOverageSMSPrice(decimal val) { this.overage_sms_price = val; }
        public bool GetIsAvailable() { return this.is_available; }
        public void SetIsAvailable(bool val) { this.is_available = val; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(this.name, "^[a-zA-Z ]*$"))
                yield return new ValidationResult("Name can't contain special characters");
            if (this.minute_limit < -1 || this.sms_limit < -1)
                yield return new ValidationResult("Limits have to be positif or -1");
            if (this.overage_minute_price < 0 || this.overage_sms_price < 0)
                yield return new ValidationResult("Overage Prices have to be positif");
            if (this.price < 0 )
                yield return new ValidationResult("Price have to be positif");
        }
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
        public DateTime? GetEndDate() { return this.end_date; }
        public void SetEndDate(DateTime val) { this.end_date = val; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.start_date < DateTime.Today)
                yield return new ValidationResult("Start date must be in the future");
            if (this.start_date > this.end_date)
                yield return new ValidationResult("Start date must be before end date");
        }
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(this.phone_number, "^[0-9]*$"))
                yield return new ValidationResult("Phone number must contain only numbers");
            if (this.start_date < DateTime.Today)
                yield return new ValidationResult("Start date must be in the future");
            if (this.start_date > this.end_date)
                yield return new ValidationResult("Start date must be before end date");
        }
    }



}
