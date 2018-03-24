import React, { Component } from 'react';

import Progress from '../Progress';

export default class Card extends Component {
	constructor(props) {
		super(props);
		this.state = {
			totalSteps: this.props.totalSteps,
			filledSteps: this.props.filledSteps,
			title: this.props.title,
			description: this.props.description,
			cluster: this.props.cluster
		}
	}
	
	render() {
		return (
			<div className={"cards__item cards__item--" + this.state.cluster}>
				<div className="cards__item__internal">
					<span className="cards__item__icon"></span>
					<span className="cards__item__steps">{this.state.filledSteps} de {this.state.totalSteps}</span>
					<h3 className="cards__item__title">{this.state.title}</h3>
					<p className="cards__item__description">{this.state.description}</p>
				</div>
				<Progress totalSteps={this.state.totalSteps} filledSteps={this.state.filledSteps} />
			</div>
		);
	}
}