﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1022
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Electros.RoleServ {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoleServ.IRoleService")]
    public interface IRoleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoleService/GetAllRoles", ReplyAction="http://tempuri.org/IRoleService/GetAllRolesResponse")]
        Common.Role[] GetAllRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoleService/GetRoleByID", ReplyAction="http://tempuri.org/IRoleService/GetRoleByIDResponse")]
        Common.Role GetRoleByID(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoleServiceChannel : Electros.RoleServ.IRoleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoleServiceClient : System.ServiceModel.ClientBase<Electros.RoleServ.IRoleService>, Electros.RoleServ.IRoleService {
        
        public RoleServiceClient() {
        }
        
        public RoleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Common.Role[] GetAllRoles() {
            return base.Channel.GetAllRoles();
        }
        
        public Common.Role GetRoleByID(int id) {
            return base.Channel.GetRoleByID(id);
        }
    }
}