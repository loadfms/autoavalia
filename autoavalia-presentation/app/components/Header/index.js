import React, { Component } from 'react';
import brandWebmotors from '../../../images/brands/brand-webmotors-color.svg';

export default class Header extends Component {
	constructor(props) {
		super(props);
		
		this.handleBackButton = this.handleBackButton.bind(this);
	}
	
	render() {
		return (
			<header className="header">
				<div className="container">
					<a className="header__back" onClick={this.handleBackButton}></a>
					<h1 className="header__brand">
						<a href="#">
							<img src={brandWebmotors} />					
						</a>
					</h1>
				</div>
			</header>
		);
	}
}