import React, { Component } from 'react';

import Progress from '../Progress';

export default class Card extends Component {
	constructor(props) {
		super(props);
		this.state = {
			title: this.props.title,
			description: this.props.description,
			cluster: this.props.cluster,
			type: this.props.type ? this.props.type : "outside",
			progress: this.props.progress,
			details: this.props.details
		}
	}

	render() {
		return (
			<div className={"cards__item cards__item--" + this.state.cluster} onClick={this.props.filledSteps == this.props.totalSteps ? null : this.props.onClick}>
				<div className="cards__item__internal">
					<span className="cards__item__icon"></span>
					{this.state.type !== "inside" && this.props.filledSteps !== undefined && this.props.totalSteps !== undefined ? <span className="cards__item__steps">{this.props.filledSteps} de {this.props.totalSteps}</span> : null}
					<h3 className="cards__item__title">{this.state.title}</h3>
					{this.state.description ? <p className="cards__item__description">{this.state.description}</p> : null}
					{this.state.progress ? (this.state.type == "inside" ? <Progress withPercent={true} totalSteps={this.props.totalSteps} filledSteps={this.props.filledSteps} /> : null) : null}
				</div>
				{this.props.children ?
					this.props.children
					 : null
				}
				{this.state.progress ? (this.state.type == "outside" ? <Progress totalSteps={this.props.totalSteps} filledSteps={this.props.filledSteps} /> : null) : null}
			</div>
		);
	}
}