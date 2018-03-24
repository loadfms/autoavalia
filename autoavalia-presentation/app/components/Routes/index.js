import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Home from './../Home';
import Panel from './../Panel';
import Report from './../Report';
import Question from './../Question';

const Routes = () => (
	<Switch>
		<Route exact path="/" component={Home} />
		<Route exact path="/painel" component={Panel} />
		<Route exact path="/report/:questionary" component={Report} />
		<Route exact path="/questao/:questionary/:id" component={Question} />
	</Switch>
);

export default Routes;