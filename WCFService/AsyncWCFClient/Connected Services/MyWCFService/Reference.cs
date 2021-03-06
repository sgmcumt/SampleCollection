﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsyncWCFClient.MyWCFService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyWCFService.IMyWCFService")]
    public interface IMyWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyWCFService/GetCourseName", ReplyAction="http://tempuri.org/IMyWCFService/GetCourseNameResponse")]
        string GetCourseName(int courseId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMyWCFService/GetCourseName", ReplyAction="http://tempuri.org/IMyWCFService/GetCourseNameResponse")]
        System.IAsyncResult BeginGetCourseName(int courseId, System.AsyncCallback callback, object asyncState);
        
        string EndGetCourseName(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyWCFServiceChannel : AsyncWCFClient.MyWCFService.IMyWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetCourseNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetCourseNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyWCFServiceClient : System.ServiceModel.ClientBase<AsyncWCFClient.MyWCFService.IMyWCFService>, AsyncWCFClient.MyWCFService.IMyWCFService {
        
        private BeginOperationDelegate onBeginGetCourseNameDelegate;
        
        private EndOperationDelegate onEndGetCourseNameDelegate;
        
        private System.Threading.SendOrPostCallback onGetCourseNameCompletedDelegate;
        
        public MyWCFServiceClient() {
        }
        
        public MyWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<GetCourseNameCompletedEventArgs> GetCourseNameCompleted;
        
        public string GetCourseName(int courseId) {
            return base.Channel.GetCourseName(courseId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetCourseName(int courseId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetCourseName(courseId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndGetCourseName(System.IAsyncResult result) {
            return base.Channel.EndGetCourseName(result);
        }
        
        private System.IAsyncResult OnBeginGetCourseName(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int courseId = ((int)(inValues[0]));
            return this.BeginGetCourseName(courseId, callback, asyncState);
        }
        
        private object[] OnEndGetCourseName(System.IAsyncResult result) {
            string retVal = this.EndGetCourseName(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetCourseNameCompleted(object state) {
            if ((this.GetCourseNameCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetCourseNameCompleted(this, new GetCourseNameCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetCourseNameAsync(int courseId) {
            this.GetCourseNameAsync(courseId, null);
        }
        
        public void GetCourseNameAsync(int courseId, object userState) {
            if ((this.onBeginGetCourseNameDelegate == null)) {
                this.onBeginGetCourseNameDelegate = new BeginOperationDelegate(this.OnBeginGetCourseName);
            }
            if ((this.onEndGetCourseNameDelegate == null)) {
                this.onEndGetCourseNameDelegate = new EndOperationDelegate(this.OnEndGetCourseName);
            }
            if ((this.onGetCourseNameCompletedDelegate == null)) {
                this.onGetCourseNameCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCourseNameCompleted);
            }
            base.InvokeAsync(this.onBeginGetCourseNameDelegate, new object[] {
                        courseId}, this.onEndGetCourseNameDelegate, this.onGetCourseNameCompletedDelegate, userState);
        }
    }
}
