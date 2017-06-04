var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var router = express.Router();
var sqlite3 = require('sqlite3').verbose()

var app = express();
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

var sqlite3 = require('sqlite3').verbose();
var db = new sqlite3.Database('db.db');


// LEADERBOARF API ROUTER
router.get('/leaderboard', function (req, res) {
  db.all('SELECT * FROM player', function (err, row) {
    res.setHeader('Content-Type', 'application/json');
    res.setHeader("Access-Control-Allow-Origin", "*");
    res.json(row);
  })
});

router.post('/game', function (req, res) {
  console.log('New request received: ')
  console.log(req.body);
  var username = req.body.username;
  var points = req.body.points;
  var time = req.body.time;
  db.run("INSERT INTO player VALUES (?, ?,?)", [username, points, time]);
  res.json("");
});

// INIT API
app.use('/', router)

// catch 404 and forward to error handler
app.use(function (req, res, next) {
  var err = new Error('Not Found');
  err.status = 404;
  next(err);
});

// error handler
app.use(function (err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'production' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;
