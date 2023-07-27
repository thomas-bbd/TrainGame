let gameId = "";
const jwtToken = localStorage.getItem("jwt");

function LoadGame() {
  const apiUrl = "https://ntgvrgrjdc.us-east-1.awsapprunner.com/Game";
  fetch(apiUrl, {
    method: "GET",
    headers: {
      Authorization: `Bearer ${jwtToken}`,
    },
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      return response.json();
    })
    .then((data) => {
      const train = data.currentQuestion.train;
      const object = data.currentQuestion.object;
      document.getElementById("option-one-label").innerText = train.trainName;
      document.getElementById("option-two-label").innerText = object.objectName;
      document.getElementById("player-score").innerText = data.score;

      gameId = data.id;
    })
    .catch((error) => {
      console.error("Error fetching data:", error);
    });
}

function NextQuestion() {
  let button = Array.from(document.getElementsByName("option"))
    .map((x) => x.checked)
    .indexOf(true);
  let answer = document.getElementsByName("answer")[button].innerText;
  const apiUrl = `https://ntgvrgrjdc.us-east-1.awsapprunner.com/Game/Question?gameId=${gameId}&answer=${answer}`;
  fetch(apiUrl, {
    method: "GET",
    headers: {
      Authorization: `Bearer ${jwtToken}`,
    },
  })
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      return response.json();
    })
    .then((data) => {
      if (data.gameOver) {
        handleEndGame(data.score);
      } else {
        const train = data.currentQuestion.train;
        const object = data.currentQuestion.object;
        document.getElementById("option-one-label").innerText = train.trainName;
        document.getElementById("option-two-label").innerText =
          object.objectName;
        document.getElementById("player-score").innerText = data.score;
      }
    })
    .catch((error) => {
      console.error("Error fetching data:", error);
    });
}

function handleEndGame(score) {
  document.getElementById("score-modal").style.display = "flex";
  document.getElementById("final-score").innerText = score;

  const apiUrl = `https://ntgvrgrjdc.us-east-1.awsapprunner.com/User/Score/Update`;
  fetch(apiUrl, {
    method: "POST",
    headers: {
      Authorization: `Bearer ${jwtToken}`,
      "Content-type": "application/json",
    },
    body: JSON.stringify({ score: score }),
  });
}
