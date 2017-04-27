using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

// class: SubmitFormGenerator
// Creates and renders to the screen a subscription form.  
public partial class SubmitFormGenerator
{
    // Form generator
    private string _method;
    private string _action;
    private bool _validate;
    
    // Stores the form
    public HtmlForm baseForm;
    
    // Constructor
    public SubmitFormGenerator(string method, string action, bool validate)
    {
        _method = method != "" ? method : "POST";
        _action = action != "" ? action : "subscribe.aspx";
        _validate = validate;
    }
    
    // renderTo
    // Renders the form to the screen, generating the form if it has not already done so.
    public void renderTo(HtmlGenericControl dest)
    {
        generateForm();

        dest.Controls.Add(baseForm);
    }

    // generateForm
    // Generates the subscription form, using the saved variables.
    private void generateForm()
    {
        // If the form's already been created, we don't need to do it again.
        if(baseForm != null) { return; }

        // Generate the form
        HtmlForm newForm = new HtmlForm();
        newForm.ID = "subscribeform";
        newForm.Method = _method;
        newForm.Action = _action;
        newForm.Attributes.Add("class", "text-center");

        // Generate the inputs
        HtmlInputText firstName = new HtmlInputText();
        HtmlInputText lastName = new HtmlInputText();
        HtmlInputText email = new HtmlInputText("email");

        firstName.ID = "firstname";
        lastName.ID = "lastname";
        email.ID = "email";

        // Ready the inputs for user-friendly display
        HtmlGenericControl firstNameCont = bootstrappy(firstName, "First Name", "Please enter your first name");
        HtmlGenericControl lastNameCont = bootstrappy(lastName, "Last Name", "Please enter your last name.");
        HtmlGenericControl emailCont = bootstrappy(email, "Email", "Please enter a valid email address.");
        
        // Add the inputs to the form
        newForm.Controls.Add(firstNameCont);
        newForm.Controls.Add(lastNameCont);
        newForm.Controls.Add(emailCont);

        // Generate the button
        HtmlButton submit = new HtmlButton();
        submit.InnerText = "Subscribe";
        submit.Attributes.Add("class", "btn btn-primary");

        // Add the button to the form
        newForm.Controls.Add(submit);

        // Store the form for later rendering and output.
        baseForm = newForm;
    }

    // bootstrappy
    // Takes an input, adds classes, placeholders, and error checking,
    // wraps it in a bootstrappy div, and returns it.
    private HtmlGenericControl bootstrappy(HtmlInputText target, string placeholder, string errorString = "", string errorRegex = "")
    {
        HtmlGenericControl outputDiv = new HtmlGenericControl("div");
        outputDiv.Attributes.Add("class", "form-group");

        Label outLabel = new Label();
        outLabel.Text = placeholder;
        outLabel.CssClass = "sr-only";
        outputDiv.Controls.Add(outLabel);

        target.Attributes.Add("placeholder", placeholder);
        target.Attributes.Add("class", "form-control");
        outputDiv.Controls.Add(target);

        // If inputs must be validated...
        if(_validate)
        {
            // Make them required
            target.Attributes.Add("required","required");
            if(errorString.Length > 0)
            {
                // Add a generic "not-empty" validator
                RequiredFieldValidator valid = new RequiredFieldValidator();
                valid.ErrorMessage = errorString;
                valid.Display = ValidatorDisplay.Dynamic;
                valid.ControlToValidate = target.ID;
                valid.ForeColor = System.Drawing.Color.Red;
                outputDiv.Controls.Add(valid);
            }
            if(errorRegex.Length > 0)
            {
                // Add an email-specific vaidator
                RegularExpressionValidator regexval = new RegularExpressionValidator();
                regexval.ErrorMessage = errorString;
                regexval.Display = ValidatorDisplay.Dynamic;
                regexval.ValidationExpression = errorRegex;
                regexval.ControlToValidate = target.ID;
                regexval.ForeColor = System.Drawing.Color.Red;
                outputDiv.Controls.Add(regexval);
            }
        }

        // Return
        return outputDiv;
    }
}