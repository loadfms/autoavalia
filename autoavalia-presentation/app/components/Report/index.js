import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import {fetchReport} from './../../actions/index';
import {withRouter} from 'react-router-dom';


export default class Report extends Component {
	constructor(props) {
		super(props);

	}

	componentWillMount() {
    fetchReport(this.props.match.params.questionary, (response)=>{
      console.log(response);
    });
	}

	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
				
				</main>
				<Footer />
			</div>
		);
	}
}