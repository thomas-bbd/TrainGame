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
    const password = document.getElementById("email").value;
    const confirmationPassword = document.getElementById("passwordConfirmation");
  
   
    if (username === "") {
      message = "Input username";
    } else if (password.length < 10) {
      message = "Input password longer than 8 characters";
    } else if (password.length > 128) {
      message = "Input password less than 128 characters";
    } else if(password.match(/\d/)===null){
      message = "Include digit in password";
    } else if(!specialCharacters.test(password)){
      specialCharacters.test(password)
      message = "Include special character in password";
    } else if(!upperCase.test(password)){
      message = "Include an upper case character in password";
    } else if(!lowerCase.test(password)){
      message = "Include lower case character in password";
    }else if(password!==confirmationPassword){
        message = "Your passwords do not match";
    }
  
    if (message != "") {
      showInvalidMessage(message);
      return false;
    }
  
    return true;
  }
  