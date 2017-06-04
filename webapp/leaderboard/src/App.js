import React, { Component } from 'react';
import Leaderboard from './components/Leaderboard';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <img className="biceps-lijevo" src={"../images/biceps_lijevo.png"} alt=""/>
        <h1>Hall of Heroes</h1>
        <img className="biceps-desno" src={"../images/biceps_desno.png"} alt=""/>
        <Leaderboard />
      </div>
    );
  }
}

export default App;
