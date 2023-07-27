function showInvalidMessage(message) {
    let snackbar = document.getElementById("snackbar");
    snackbar.className = "show";
    snackbar.innerText = message;
    setTimeout(function () { snackbar.className = snackbar.className.replace("show", ""); snackbar.innerText = ""; }, 3000);
  }
  
  
  function validatePassword() {
    let message = "";

    const specialCharacters = /[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const upperCase = /[A-Z]/
    const lowerCase = /[a-z]/ 

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    const confirmationPassword = document.getElementById("passwordConfirmation");
  
   
    if (username === "") {
      message = "Input username";
    }
    // } else if (password.length < 10) {
    //   message = "Input password longer than 8 characters";
    // } else if (password.length > 128) {
    //   message = "Input password less than 128 characters";
    // } else if(password.match(/\d/)===null){
    //     console.log(password)
    //   message = "Include digit in password";
    // } else if(!specialCharacters.test(password)){
    //   specialCharacters.test(password)
    //   message = "Include special character in password";
    // } else if(!upperCase.test(password)){
    //   message = "Include an upper case character in password";
    // } else if(!lowerCase.test(password)){
    //   message = "Include lower case character in password";
    // }else if(password!==confirmationPassword){
    //     message = "Your passwords do not match";
    // }
  
    if (message != "") {
      showInvalidMessage(message);
      return false;
    }
  
    return true;
  }

  function registerUser(event) {
    event.preventDefault();
    // togglePopup()

    try{

        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        const email = document.getElementById('email').value;
        // Add other form field values as needed
        
        if(!validatePassword()){
            return;
        }

        const attributeList = [
            new AmazonCognitoIdentity.CognitoUserAttribute({ Name: 'email', Value: email }),
            new AmazonCognitoIdentity.CognitoUserAttribute({ Name: 'preferred_username', Value: username }),
            // Add other attributes as needed
        ];
        userPool.signUp(username, password, attributeList, null, function (err, result) {
        if (err) {
            console.error('Error registering user:', err.message || JSON.stringify(err));
            return;
        }else{
            document.getElementById('registerUserForm').style.display = 'none';
            document.getElementById('confirmRegister').style.display = 'flex';
        }
        // You can redirect the user to a confirmation page or perform other actions here.
        });
    }catch(e){
        console.log(e)
    }
}
  