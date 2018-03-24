import React, { Component } from 'react';
import brandWebmotors from '../../../images/brands/brand-webmotors-color.svg';
import {withRouter} from 'react-router-dom';

export default class Header extends Component {
	render() {
		return (
			<header className="header">
				<div className="container">
					<a className="header__back" onClick={this.props.onClickBackButton}></a>
					<h1 className="header__brand">
						<a href="#">
							<img src={brandWebmotors} />					
						</a>
					</h1>
					<a className="header__menu" onClick={this.props.onClick}></a>
				</div>
			</header>
		);
	}
}