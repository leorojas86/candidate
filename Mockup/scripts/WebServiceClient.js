
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
	/*$.ajax(
	{ 
        type: 'GET', 
        url: this.serverURL + 'Contacts/Get', 
        success: function(data, status, xhr) { callback(data); }
        error:   function(data, status, xhr) 
        {
        	var errorData = { Success : false, Data : data }; 
        	callback(data); 
        }
    });*/

	this.ajax('GET','Contacts/Get', callback);
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
        	callback(data); 
        }
    });
};