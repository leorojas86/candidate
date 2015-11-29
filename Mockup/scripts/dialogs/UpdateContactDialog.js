//Variables
UpdateContactDialog.prototype.updateContactDiv = null;
UpdateContactDialog.prototype.onUpdateClicked  = null;
UpdateContactDialog.prototype.contactData  	   = null;


//Constructors
function UpdateContactDialog()
{
	this.updateContactDiv = $("#updateContactDialog");

	var thisVar = this;
	$("#updateContactDialogButton").click(function() { thisVar.onUpdateContactButtonClick(); });
	$("#updateContactDialogGrayout").click(function() { thisVar.hide(); });
}

UpdateContactDialog.prototype.onUpdateContactButtonClick = function()
{
	this.contactData.Name  = $("#updateContactName").val();
	this.contactData.Email = $("#updateContactEmail").val();
	this.contactData.Phone = $("#updateContactPhone").val();

 	this.onUpdateClicked(this.contactData);
 	this.hide();
}

//Methods
UpdateContactDialog.prototype.show = function(contactData, onUpdateClicked)
{
	this.contactData 	 = contactData;
	this.onUpdateClicked = onUpdateClicked;

	$("#updateContactName").val(contactData.Name);
	$("#updateContactEmail").val(contactData.Email);
	$("#updateContactPhone").val(contactData.Phone);

	this.updateContactDiv.show();
};

UpdateContactDialog.prototype.hide = function()
{
	this.updateContactDiv.hide();
}