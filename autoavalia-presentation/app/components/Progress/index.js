import React, { Component } from 'react';

export default class Progress extends Component {
	constructor(props) {
		super(props);
		this.state = {
			filledSteps: this.props.filledSteps,
			totalSteps: this.props.totalSteps,
			withPercent: this.props.withPercent
		}
	}
	
	render() {
		let _percent = this.state.filledSteps / this.state.totalSteps * 100;
		let _progressStyle = {
			width: _percent + '%'
		}
		return (
			<div className="progress progress--inside">
				<div className="progress__internal">
					<span style={_progressStyle} className="progress__bar"></span>
				</div>
				{this.state.withPercent ? <span className="progress__percent">{_percent + "%"}</span> : null}
			</div>
		);
	}
}