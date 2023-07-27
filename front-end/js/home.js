document.addEventListener("DOMContentLoaded", function () {
  const menuHamburger = document.querySelector(".burger");
  const navLinks = document.querySelector(".navbar");

  menuHamburger.addEventListener("click", () => {
    navLinks.classList.toggle("mobile-menu");
  });
});

function PopulateScoreboard() {
  var scoreboard = document.getElementById("scoreboard");

  scores.forEach(user => {
    var li = document.createElement("LI");
    li.innerText = `${user.userName} - `;
    var bold = document.createElement("B");
    bold.innerText = user.highScore;
    li.appendChild(bold);
    scoreboard.appendChild(li);
  });
}