
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
    this.ajax('POST','Contacts/Add/' + name + '/' + email + '/' + phone, callback);
};

WebServiceClientClass.prototype.updateContact = function(id, name, email, phone, callback)
{
    this.ajax('POST','Contacts/Update/' + id + '/' + name + '/' + email + '/' + phone, callback);
};

WebServiceClientClass.prototype.deleteContact = function(id, callback)
{
    this.ajax('POST','Contacts/Delete/' + id, callback);
};

WebServiceClientClass.prototype.ajax = function(method, resourceURI, callback)
{
    var thisVar = this;

	$.ajax(
	{ 
        type: method, 
        url: this.serverURL + resourceURI, 
        dataType: "json",
        data: null,
        success: function(data, status, xhr) 
        { 
            if(!data.Success)
                thisVar.logError(data);

            callback(data); 
        },
        error:   function(data, status, xhr) 
        {
        	var errorData = { Success : false, Data : data };
            
            thisVar.logError(errorData);
        	callback(errorData); 
        }
    });
};

WebServiceClientClass.prototype.logError = function(errorData)
{
    console.log(JSON.stringify(errorData));
}