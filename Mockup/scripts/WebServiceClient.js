
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
	$.ajax(
	{ 
        type: 'GET', 
        url: this.serverURL + 'Contacts/Get', 
        success: function (data) { callback(data); }
    });
};