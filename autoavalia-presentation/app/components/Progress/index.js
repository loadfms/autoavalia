import React, { Component } from 'react';

export default class Progress extends Component {
	constructor(props) {
		super(props);
		this.state = {
			withPercent: this.props.withPercent
		}
	}

	render() {
		let _percent = 0;
		let _progressStyle = {
			width: '0%'
		};
		if (this.props.totalSteps > 0 && this.props.filledSteps > 0) {
			_percent = Math.round(this.props.filledSteps / this.props.totalSteps * 100);
			_progressStyle = {
				width: _percent + '%'
			}
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