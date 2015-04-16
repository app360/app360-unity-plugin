package com.example.app360wrapper;

import vn.mog.app360.sdk.payment.interfaces.AmountConverter;
import vn.mog.app360.sdk.payment.utils.Const;

class MyAmountConverter implements AmountConverter {
    @Override
    public String smsAmountToString(Const.SmsAmount amount) {
        switch (amount) {
            case AMOUNT_500:
                return "50000xu";
            case AMOUNT_1000:
                return "1000xu";
            case AMOUNT_2000:
                return "200000xu";
            case AMOUNT_3000:
                return "3000xu";
            case AMOUNT_4000:
                return "400000xu";
            case AMOUNT_5000:
                return "5000xu";
            case AMOUNT_10000:
                return "10000xu";
            case AMOUNT_15000:
                return "15000xu";
            default:
                return "500xu";
        }
    }

    @Override
    public String bankAmountToString(int amount) {
        switch (amount) {
            case 50000:
                return "50000xu";
            case 100000:
                return "1000xu";
            case 200000:
                return "200000xu";
            default:
                return "50000000xu";
        }
    }

    @Override
    public String cardAmountToString(int amount) {
        switch (amount) {
            case 10000:
                return "10000xu";
            case 15000:
                return "10500xu";
            case 200000:
                return "200000xu";
            default:
                return "50000000xu";
        }
    }
}
