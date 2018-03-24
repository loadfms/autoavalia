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
			cluster: this.props.cluster,
			type: this.props.type ? this.props.type : "outside",
		}
	}
	
	render() {
		return (
			<div className={"cards__item cards__item--" + this.state.cluster}>
				<div className="cards__item__internal">
					<span className="cards__item__icon"></span>
					{this.state.type !== "inside" && this.state.filledSteps !== undefined && this.state.totalSteps !== undefined ? <span className="cards__item__steps">{this.state.filledSteps} de {this.state.totalSteps}</span> : null}
					<h3 className="cards__item__title">{this.state.title}</h3>
					{ this.state.description ? <p className="cards__item__description">{this.state.description}</p> : null }
					{ this.state.type == "inside" ? <Progress withPercent={true} totalSteps={this.state.totalSteps} filledSteps={this.state.filledSteps} /> : null }
				</div>
				{ this.state.type == "outside" ? <Progress totalSteps={this.state.totalSteps} filledSteps={this.state.filledSteps} /> : null }
			</div>
		);
	}
}