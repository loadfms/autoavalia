import React, { Component } from 'react';

export default class Progress extends Component {
	constructor(props) {
		super(props);
		this.state = {
			currentStep: this.props.currentStep,
			totalSteps: this.props.totalSteps
		}
	}
	
	render() {
		let _percent = this.state.currentStep / this.state.totalSteps * 100;
		let _progressStyle = {
			width: _percent + '%'
		}
		return (
			<div className="progress progress--internal">
				<span style={_progressStyle} className="progress__bar"></span>
			</div>
		);
	}
}