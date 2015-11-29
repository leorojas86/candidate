//Variables
UpdateContactDialog.prototype.updateContactDiv = null;
UpdateContactDialog.prototype.onUpdateClicked     = null;

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
 	this.onUpdateClicked($("#updateContactName").val(), $("#updateContactEmail").val(), $("#updateContactPhone").val());
 	this.hide();
}

//Methods
UpdateContactDialog.prototype.show = function(contactData, onUpdateClicked)
{
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