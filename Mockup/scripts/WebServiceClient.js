
//Singleton instance
var WebServiceClient = { Instance : new WebServiceClientClass() };

//Variables
WebServiceClientClass.prototype.serverURL = null;

//Constructors
function WebServiceClientClass()
{
	this.serverURL = Config.WebServiceURL;
}

//Methods
WebServiceClientClass.prototype.getContacts = function(callback)
{
	this.ajax('GET','Contacts/Get', callback);
};

WebServiceClientClass.prototype.addContact = function(name, email, phone, callback)
{
    this.ajax('POST','Contacts/Add/' + name + "/" + email + '/' + phone, callback);
};


WebServiceClientClass.prototype.ajax = function(method, resourceURI, callback)
{
	$.ajax(
	{ 
        type: method, 
        url: this.serverURL + resourceURI, 
        dataType: "json",
        success: function(data, status, xhr) { callback(data); },
        error:   function(data, status, xhr) 
        {
        	var errorData = { Success : false, Data : data }; 
        	callback(errorData); 
        }
    });
};