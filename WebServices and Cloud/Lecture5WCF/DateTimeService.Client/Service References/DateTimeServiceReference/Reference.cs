﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DateTimeService.Client.DateTimeServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DateTimeServiceReference.IDateTimeService")]
    public interface IDateTimeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateTimeService/GetDayOfWeek", ReplyAction="http://tempuri.org/IDateTimeService/GetDayOfWeekResponse")]
        string GetDayOfWeek(System.DateTime value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDateTimeService/GetDayOfWeek", ReplyAction="http://tempuri.org/IDateTimeService/GetDayOfWeekResponse")]
        System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDateTimeServiceChannel : DateTimeService.Client.DateTimeServiceReference.IDateTimeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DateTimeServiceClient : System.ServiceModel.ClientBase<DateTimeService.Client.DateTimeServiceReference.IDateTimeService>, DateTimeService.Client.DateTimeServiceReference.IDateTimeService {
        
        public DateTimeServiceClient() {
        }
        
        public DateTimeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DateTimeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateTimeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DateTimeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDayOfWeek(System.DateTime value) {
            return base.Channel.GetDayOfWeek(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDayOfWeekAsync(System.DateTime value) {
            return base.Channel.GetDayOfWeekAsync(value);
        }
    }
}
