const loginRedirectBtn = document.getElementById("login-redirect");
const registerSection = document.getElementById("register-section");
const authSection = document.getElementById("auth-section");
const mainAside = document.getElementById("main-aside");
const overlay = document.getElementById('popupOverlay');
const inlineError = document.getElementById('error-inline');


const baseURI = window.location.origin;

loginRedirectBtn.addEventListener("click", (e) => {
    e.preventDefault();
    window.location.replace(baseURI)
});


const poolData = {
    UserPoolId: 'us-east-1_6iVfhJwtH',      // Replace with your actual User Pool ID
    ClientId: 'l0nhuftvutntsqncbcraodmct',       // Replace with your actual App Client ID
};

const userPool = new AmazonCognitoIdentity.CognitoUserPool(poolData);

function validatePassword(password){
    const passwordRegex = new RegExp(/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/);
    if(!passwordRegex.test(password)){
        inlineError.innerText = "Invalid password, you need 1 uppercase, 1 lowercase, 1 special character, a number and a minimum of 8 characters."
        setTimeout(() => {inlineError.innerText = ''}, 10000)
    }

    return passwordRegex.test(password);
};

function registerUser(event) {
    event.preventDefault();    
    try{
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        const email = document.getElementById('email').value;
        
        if(!validatePassword(password)){
            return;
        }

        const attributeList = [
            new AmazonCognitoIdentity.CognitoUserAttribute({ Name: 'email', Value: email }),
            new AmazonCognitoIdentity.CognitoUserAttribute({ Name: 'preferred_username', Value: username }),
        ];
        userPool.signUp(username, password, attributeList, null, function (err, result) {
        if (err) {
            console.error('Error registering user:', err.message || JSON.stringify(err));
            inlineError.innerText = err.message || JSON.stringify(err);
            return;
        }else{
            authSection.style.display = "block";
            registerSection.style.display = "none";
        }
        });
    } catch(e) {
        console.log(e)
    }
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
            mainAside.style.display = "none";
            overlay.style.display = "block";
            setTimeout(()=> {window.location.replace(baseURI)}, 5000);
        }
    });

}