document.addEventListener("DOMContentLoaded", function () {
  const menuHamburger = document.querySelector(".burger");
  const navLinks = document.querySelector(".navbar");

  menuHamburger.addEventListener("click", () => {
    navLinks.classList.toggle("mobile-menu");
  });
});

async function PopulateScoreboard() {
  var scoreboard = document.getElementById("scoreboard");
  const jwtToken = localStorage.getItem("jwt");
  const apiUrl = "https://ntgvrgrjdc.us-east-1.awsapprunner.com/User/Scores";
  const response = await fetch(apiUrl, {
    method: "GET",
    headers: {
      Authorization: `Bearer ${jwtToken}`

    },
  })
    
  let scores = await response.json();

    scores.forEach(user => {
    var li = document.createElement("LI");
    li.innerText = `${user.userName} - `;
    var bold = document.createElement("B");
    bold.innerText = user.highScore;
    li.appendChild(bold);
    scoreboard.appendChild(li);
  });
}