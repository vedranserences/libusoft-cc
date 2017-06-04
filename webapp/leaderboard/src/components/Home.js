import React, { Component } from 'react';
import './Home.css';
import './animate.css';
import './hover-min.css';

class Home extends Component {
    constructor(props) {
        super(props);
        };
  render() {

    return (
        <div className="container">
            <header>
                <h1 id='title' className="hvr-wobble-top" ><span className="letter-M">M</span><span className="letter-a">a</span><span className="letter-z">z</span><span className="letter-e">e</span><span
                className="letter-s">s</span><span className="letter-c">c</span><span className="letter-a a2">a</span><span className="letter-p">p</span><span
                    className="letter-e">e</span>
             </h1>
            </header>
            <main>
                <a href="/leaderboard"><div id="leaderboard-button-container">
                    <h1 id="leaderboard-title">LEADERBOARD</h1>
                </div></a>
                
                <div className="image-container">
                    <img className="earth-image" src="images/earth.png" alt=""/>
                    <img className="nlo-large hvr-buzz-out" src="images/nlo.png" alt=""/>
                    <img className="nlo-medium hvr-buzz-out" src="images/nlo.png" alt=""/>
                    <img className="nlo-small hvr-buzz-out" src="images/nlo.png" alt=""/>
                </div>
            </main>
        </div>
      
    );
  }
}
export default Home;
