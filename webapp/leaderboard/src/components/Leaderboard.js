import React, { Component } from 'react';
import './Leaderboard.css';
import PlayerItem from './PlayerItem';
import 'whatwg-fetch';

class Leaderboard extends Component {
    constructor(props) {
        super(props);
        this.state = {
            players: []
        };
    }
  render() {

    return (

      <div className="leaderboard">
          <ul className="leaderboard-header">
              <li className="place">Place</li>
              <li className="user">User</li>
              <li className="points">Points</li>
          </ul>
          <ul className="leaderboard-list">
              {this.state.players.map((player, index) => 
              <PlayerItem key={index} data={player} place={index}/>
            )}
        </ul>
      </div>
    );
  }

  componentWillMount() {
      fetch('http://localhost:4200/leaderboard')
        .then(res=>res.json())
        .then(json => {
            json.sort(function(a,b) {
                return b.points -  a.points;
            })
            console.log(json);
            this.setState({players: json});
        });
  }
}

export default Leaderboard;
