import React, { Component } from 'react';
import './PlayerItem.css';

class PlayerItem extends Component {
  render() {
      let place;
      if((this.props.place+1) === 1 ) {
        place = (
          <img className="first-place" type="" src="images/place1.png" />
        )
      }
      else if((this.props.place+1) == 2) {
          place = (
          <img className="second-place" type="" src="images/place2.png" />
        )
      }
      else if((this.props.place+1) == 3) {
          place = (
          <img className="third-place" type="" src="images/place3.png" />
        )
      } 
      else {
        place = this.props.place+1;
      }

    return (
        <li className="player-statistic">
            <span className="player-place">{place}</span>
            <span className="player-username">{this.props.data.username}</span>
            <span className="player-points">{this.props.data.points}</span>
            <hr/>
        </li>
    ) ;
  }
}

export default PlayerItem;
