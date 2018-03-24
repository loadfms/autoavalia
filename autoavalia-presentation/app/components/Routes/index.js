import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Home from './../Home';
import Panel from './../Panel';
import Question from './../Question';

const Routes = () => (
	<Switch>
		<Route exact path="/" component={Home} />
		<Route exact path="/painel" component={Panel} />
		<Route exact path="/questao/:id" component={Question} />
	</Switch>
);

export default Routes;