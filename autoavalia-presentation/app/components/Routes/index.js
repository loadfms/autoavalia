import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Home from './../Home';
import Panel from './../Panel';

const Routes = () => (
	<Switch>
		<Route exact path="/" component={Home} />
		<Route exact path="/painel" component={Panel} />
	</Switch>
);

export default Routes;