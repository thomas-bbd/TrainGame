const poolData = {
    UserPoolId: 'us-east-1_6iVfhJwtH',      // Replace with your actual User Pool ID
    ClientId: 'l0nhuftvutntsqncbcraodmct',       // Replace with your actual App Client ID
};
const userPool = new AmazonCognitoIdentity.CognitoUserPool(poolData);
function loginUser(event) {
event.preventDefault();

const username = document.getElementById('username').value;
const password = document.getElementById('password').value;
const inlineError = document.getElementById('error-inline');

const authenticationData = {
    Username: username,
    Password: password,
};

const authenticationDetails = new AmazonCognitoIdentity.AuthenticationDetails(authenticationData);
const userData = {
    Username: username,
    Pool: userPool,
};

const cognitoUser = new AmazonCognitoIdentity.CognitoUser(userData);

cognitoUser.authenticateUser(authenticationDetails, {
    onSuccess: function (session) {
    localStorage.setItem('jwt',session.getAccessToken().getJwtToken())
    window.location.href = "/front-end/home.html"
},
    onFailure: function (err) {
    inlineError.innerText=err.message;
    console.error('Error logging in:', err.message || JSON.stringify(err));
    },
});
}

function Register(event) {
    event.preventDefault();
    window.location.href = "/front-end/register.html"
}