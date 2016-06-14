$( document ).ready(function(){

var CountOfTurns = null;
var TeamsNumber = null;
var SetTimer = 3;
var MainTimer;
PrepareGame();
$('.q-box').on('click', function(){ Qchosen(this); });
$('#q-close').on('click', function(){ CloseQ(this); });
$('#q-correct').on('click', function(){ CorrectAnswer(this); });
$('#q-uncorrect').on('click', function(){ UncorrectAnswer(this); });
$('.stork').on('click', function(){ show_answer();});
$('.menu_handler').on('click', function(){ menuCO(this);});


function menuCO(handler){
	var menu = $(handler).parents('.menu_frame');
	if(menu.hasClass('active')){
		menu.removeClass('active');
	}
	else
	{menu.addClass('active');}

}

function Qdone(box){	
$(box).css('opacity', '1').animate({ "opacity": '0' }, "slow").addClass('done').parents('.game-frame').hide();
$('.question-frame').show();

};

function Qchosen(q){
	var question = $(q);
	
	var t = question.parents('.q-col').find('.theme-label').html();
	var q = question.find('.question').html();
	var a = question.find('.answer').html();
	var s = question.find('.points').html();
	question.addClass('current');
	question.parents('.game-frame').hide();
	RevilQ(t, q, a, s);
}

function RevilQ (t, q, a, s){
	var question = $('.question-frame');
	question.find('.theme').html(t);
	var qt = question.find('.question');
	qt.html(q);
	var qa = question.find('.answer').html(a).css('visibility', 'visible');
	question.find('.score').html(s);
	question.show();
	cd_timer(SetTimer);
	
	
}

function CloseQ(q){
	var question = $(q);
	
	var question = $('.question-frame');
	question.find('.theme').html('');
	// question.find('.question').html('');
	// question.find('.answer').html('');
	question.find('.score').html('');
	question.hide();
	$('.current').removeClass('current');
	$('.game-frame').show();
}

function CorrectAnswer(q){
	incriseScore(q);
	nextTurn();
	CloseQ(this);
	counter();
};

function UncorrectAnswer(q){
	nextTurn();
	CloseQ(this);
	counter();
};

function addPoints( score, add){
	return parseInt(score, 10) + parseInt(add, 10);
}

function incriseScore(q){
	var add = $(q).parents('.question-frame').find('.score').html();
	var score = $('.turn').find('.score').html();
	$('.turn').find('.score').html( addPoints( score, add) );
}

function nextTurn(){
	$('.current').addClass('done')
	var next = $('.turn').next('.team');
	$('.turn').removeClass('turn');
	if(next.hasClass('team')){
		next.addClass('turn')
	}
	else{
		$('.team').first().addClass('turn');
	}
}

function PrepareGame(){
	var settings = { "teams":"3", "themes":"3", "questions":"3" };
	var teamList = [ "Brains", "Nuts", "Bugs"];
	var themeList = [
	{"label": "Theme1", "questions":[{"q":"qqq1","a":"aaa1"},{"q":"qqq2","a":"aaa2"}, {"q":"qqq3","a":"aaa3"}]  }, 
	{"label": "Theme2", "questions":[{"q":"qqq1","a":"aaa1"},{"q":"qqq2","a":"aaa2"}, {"q":"qqq3","a":"aaa3"}]  },
	{"label": "Theme3", "questions":[{"q":"qqq1","a":"aaa1"},{"q":"qqq2","a":"aaa2"}, {"q":"qqq3","a":"aaa3"}]  }
	];
	
     CountOfTurns = settings.themes * settings.questions;
	 TeamsNumber = settings.teams;
	 var Qdata = addCol(themeList);
	 var Tdata = addTeams(teamList);
	 
	$('.score_field').append(Tdata);
	$('.game_field').append(Qdata); 

	}

function addTeams(TL){
	var text = '';
	for(var i=0; i<TL.length; i++){
		text+= '<div class="team' ;
		if(i==0){ text+=' turn';};
		text+= '" id="T';
		text+= parseInt(i, 10)+1;
		text+= '"><div class="team-name">';
		text+= TL[i];	
		text+= '</div><div class="score">0</div></div>';
	}
	return text;
}

function addCol(QL){
	var text = '';
	for(var i=0; i<QL.length; i++){
		text+= Qcol(QL[i]);
	}
	return text;
}

function Qcol(theme){
var text =	'<div class="q-col"><div class="q-box-theme"><div class="theme-label">'+theme.label+'</div></div><div class="q-box-conteiner">';
    text += addQ(theme.questions);
	text += '</div></div>';
	return text;
}

function addQ(ql){
	var text = '';
	for(var i=0; i<ql.length; i++){
		text+= '<div class="q-box"><div class="points">';
		text+= 100*(parseInt(i, 10)+1);
		text+=  '</div>';
		text+=  '<div class="question">'
		text+= ql[i].q;
		text+= '</div>';
		text+=  '<div class="answer">';
		text+= ql[i].a;
		text+='</div></div>';
	}
	return text;
}

function counter(){
	if(CountOfTurns==null){
		alert('Hey Ho!!');
	};
	CountOfTurns-=1;
	if(CountOfTurns==0){
		gameOver();
	};
	
}

function gameOver ( ) {
	
	var results= findWinner();
	var winners =results.winersname;
	var winnersNames = [];
	if(winners.length == TeamsNumber){
		winnersNames.push('FRIENDSHIP');
	}
	else{
	for(var i=0; i<winners.length; i++){
		winnersNames.push($(winners[i]).find('.team-name').html());
	}
	}
	fillWinnersForm(chosetitle(winners.length), winnersNames, results.winersscore);
	endTheGame();
}

function fillWinnersForm(title, tn, ts){
	$('#result_title').html(title);
	$('.winner').html(tn);
	$('.winners-score').html('Score:'+ts);
}

function chosetitle(winersNumber){
	if( winersNumber == TeamsNumber || winersNumber == 1 ){
		return 'The winner is';
	}
	return 'The winners are';
}

function endTheGame(){
	$('.question-frame').hide();
	$('.game-frame').hide();
	$('.results-frame').show();
}

function findWinner () {
	var teams=$('.team');
	var winner = [];
	winner.push(teams[0]);
	var winnersScore = $(teams[0]).find('.score').html();
	for(var i=1; i<teams.length; i++){
		var currentScore = $(teams[i]).find('.score').html();
		for(var j=0; (j<winner.length && winner.length < teams.length); j++)
		{ 
			if(parseInt(currentScore, 10)>parseInt(winnersScore, 10))
			{ 
				winner = [];
				winner.push(teams[i]);
				winnersScore = currentScore;
			};
			if(parseInt(currentScore, 10)==parseInt(winnersScore, 10))
			{ 
				winner.push(teams[i]);
			};
		};
	};
	return {winersname:winner,winersscore:winnersScore}
}

});


function cd_timer(counter){
	var timer = $('.timer');
	timer.fadeIn();
	$('.stork').html('Stop timer and show the answer').show();
	$('.answer').hide();
	$('.q-btn').hide();
	var tcounter = $(timer).find('.timer_counter');
	var tcircle = timer.find('.timer_circle');
	tcounter.html(counter);
	MainTimer = setInterval(function() {  
	tcounter.css('opacity','1');
	tcounter.html(counter);
	tcounter.animate({opacity:0}, 900)
	
	counter-=1;
	if (counter==-1){
	stop_timer();
	
	$('.stork').html('Show the answer');
		}
	}, 1000);
	
}

function stop_timer(){
	$('.timer').hide();
	clearInterval(MainTimer);
}

function show_answer(){
	stop_timer();
	$('.stork').hide();
	$('.answer').fadeIn("slow");	
	$('.q-btn').fadeIn("slow");
}
