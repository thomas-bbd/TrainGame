const poolData = {
    UserPoolId: 'us-east-1_6iVfhJwtH',      // Replace with your actual User Pool ID
    ClientId: 'l0nhuftvutntsqncbcraodmct',       // Replace with your actual App Client ID
};

const userPool = new AmazonCognitoIdentity.CognitoUserPool(poolData);

function validatePassword(){
    const password = document.getElementById('password').value;
    const passwordRegex = new RegExp(/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/);
    const inlineError = document.getElementById('error-inline');
    if(!passwordRegex.test(password)){
        inlineError.innerText = "Invalid password, you need 1 uppercase, 1 lowercase, 1 special character, a number and a minimum of 8 characters."
        setTimeout(() => {inlineError.innerText = ''}, 10000)
    }

    return passwordRegex.test(password);
};

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

function togglePopup() {
    var overlay = document.getElementById('popupOverlay');
    overlay.style.display = overlay.style.display === 'block' ? 'none' : 'block';
}

function authorizeUser(event){

    event.preventDefault();
    const username = document.getElementById('username').value;
    const authCode = document.getElementById('auth-code').value;

    const userData = {
        Username: username,
        Pool: userPool,
    };
      
    const cognitoUser = new AmazonCognitoIdentity.CognitoUser(userData);
    cognitoUser.confirmRegistration(authCode, true, (err, result) => {
        if (err) {
          console.log('Confirmation error:', err.message || JSON.stringify(err));
        } else {
            togglePopup()
            setTimeout(()=> {window.location.replace('https://dnhcmoxb4x8e8.cloudfront.net/')}, 5000);
        //   go to login
        }
    });

}

function navToLogin(){
    window.location.href = "../.../index.html"
}